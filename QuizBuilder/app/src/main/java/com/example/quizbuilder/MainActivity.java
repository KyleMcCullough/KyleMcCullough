package com.example.quizbuilder;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void onClick(View v)
    {

        EditText text = findViewById(R.id.NameEntry);

        // Checks if user entered their name.
        if (text.getText().toString().equals(""))
        {
            Toast toast = Toast.makeText(getApplicationContext(),"You must enter your name.", Toast.LENGTH_SHORT);
            toast.show();
            return;
        }

        Intent intent = new Intent(this, QuizActivity.class);
        Bundle extras = new Bundle();
        extras.putString("userName", text.getText().toString());
        intent.putExtras(extras);

        startActivity(intent);
    }

}
