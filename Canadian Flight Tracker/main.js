let map = L.map('theMap').setView([42, -60], 4);
let markers = new Array();

(function(){

    //create map in leaflet and tie it to the div called 'theMap'
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    RefreshPlaneData();
})();


function RefreshPlaneData()
{
    let timeAtStart = new Date();
    
    // Fetch the latest data.
    fetch('https://opensky-network.org/api/states/all')
    .then(function(response){
        return response.json();
    })
    .then(function(json){

        data = json.states;
        console.log('Fetching the plane data took ' + (new Date() - timeAtStart) / 1000 + ' seconds.');

        // Filters flights to only those with Canadian origin and those that have coordinates.
        data = data.filter(flight => flight[2] == 'Canada' && flight[6] != null && flight[5] != null);
        console.log(data);

        // Convert flight information to geoJSON format.
        let geoJSON = new Array();
        data.map(flight => 
            geoJSON.push(
            {
                "type": "FeatureCollection",
                "features": [
                    {
                        "type": "Feature",
                        "geometry": {
                            "type": "Point",
                            "coordinates": [flight[6], flight[5]]
                        },
                        "properties": {
                            "transponder": flight[0],
                            "velocity": flight[9],
                            "callsign": flight[1],
                            "on_ground": flight[8],
                            "geo_altitude": flight[13],
                            "true_track": flight[10]
                        }
                    }
            ]})
        );

        console.log(geoJSON);
        
        // Remove all markers from the map, then destroy the list, making a new one.
        markers = markers.map( marker => marker.remove());
        markers = new Array();
        
        geoJSON.map(function(geo){

            geoInfo = geo.features[0];
            try {


                // Creates a marker on the map with data about the flight.
                markers.push(L.marker([geoInfo.geometry.coordinates[0], geoInfo.geometry.coordinates[1]]).addTo(map)

                    .bindPopup('<h1>Callsign ' + geoInfo.properties.callsign +
                    '</h1><br><h3>Transponder ID: ' + geoInfo.properties.transponder +
                    '<br>Current Velocity: ' + geoInfo.properties.velocity +
                    '<br>On ground: ' + geoInfo.properties.on_ground +
                    '<br>Altitude: ' + geoInfo.properties.geo_altitude +
                    '<br>Latitude: ' + geoInfo.geometry.coordinates[0] +
                    '<br>Longitude: ' + geoInfo.geometry.coordinates[1] + '</h3>')
                    
                    // Sets image and rotation.
                    .setIcon(
                        L.icon({
                        iconUrl: 'plane4-45.png',
                        iconSize: [50, 50],
                        shadowSize: [40, 50],
                        popupAnchor: [-5, -15]
                    }))
                    
                    .setRotationAngle(geoInfo.properties.true_track));


            } catch (error) {
                console.log("Error showing geoJson " + geo);
            }
            
        });

        // Calls the refresh function at the end to make sure there are never 2 processes going on at once.
        WaitAndRefresh(7);
        
    },0);
}

// Function to wait the specified number of seconds before refreshing the plane. 
async function WaitAndRefresh(seconds)
{
    await new Promise(r => setTimeout(r, seconds * 1000));
    RefreshPlaneData();
}