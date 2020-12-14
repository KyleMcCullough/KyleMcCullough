package com.example.quizbuilder;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.Objects;

public class QuizActivity extends AppCompatActivity {

    ArrayList<String> definitions = new ArrayList<>();
    ArrayList<RadioButton> listOfRadioButtons = new ArrayList<>();
    HashMap<String, String[]> questionsHash = new HashMap<String, String[]>();
    RadioGroup questionRadioGroup;
    Button submitButton;
    Button resetButton;
    TextView userName;
    String correctAnswer;
    int totalCorrect = 0;
    int totalCompletedQuestions;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_quiz);

        questionRadioGroup = findViewById(R.id.questionRadioGroup);

        //Adds all of the radio buttons into an array list.
        for (int i = 0; i < questionRadioGroup.getChildCount(); i++) {
            View radioButton = questionRadioGroup.getChildAt(i);
            listOfRadioButtons.add((RadioButton) radioButton);
        }

        submitButton = findViewById(R.id.submitButton);
        resetButton = findViewById(R.id.resetBtn);

        // Gets and sorts the questions, then displays the first question.
        try {
            sortQuestionsAndAnswers();
            generateQuestion();
        } catch (IOException e) {
            Log.println(Log.ERROR,"GENERAL_ERROR", Objects.requireNonNull(e.getMessage()));
        }

        userName = findViewById(R.id.nameTextView);
        Bundle extras = getIntent().getExtras();

        if (extras != null) {
            userName.setText(extras.getString("userName"));
        }


        try {
            //Listener to submit the current question.
            submitButton.setOnClickListener(new View.OnClickListener() {
                @SuppressLint("ShowToast")
                @Override
                public void onClick(View v) {

                    //Checks if a radio button is selected. If none are, return.
                    if (questionRadioGroup.getCheckedRadioButtonId() == -1) return;

                    Toast toast;

                    //Gets the selected answer for validating if it is correct and resets it.
                    RadioButton submittedAnswer = findViewById(questionRadioGroup.getCheckedRadioButtonId());
                    submittedAnswer.setChecked(false);
                    submittedAnswer.setBackgroundColor(Color.WHITE);

                    if (submittedAnswer.getText().toString().equals(correctAnswer)) {

                        toast = Toast.makeText(getApplicationContext(),"Correct answer!", Toast.LENGTH_SHORT);
                        totalCorrect ++;

                    } else {
                        toast = Toast.makeText(getApplicationContext(),"Incorrect answer.", Toast.LENGTH_SHORT);
                    }

                    totalCompletedQuestions ++;
                    toast.show();
                    generateQuestion();
                }
            });
        } catch (Exception e) {
            Log.println(Log.ERROR,"SUBMIT_ERROR", Objects.requireNonNull(e.getMessage()));
        }

        try {
            //Listener to reset quiz if pressed
            resetButton.setOnClickListener(new View.OnClickListener() {

                @Override
                public void onClick(View v) {
                    try {

                        //Clears all arrays, hash, and then generates a new set of questions.
                        definitions.clear();
                        questionsHash.clear();
                        sortQuestionsAndAnswers();
                        generateQuestion();
                        totalCorrect = 0;
                        totalCompletedQuestions = 0;

                    } catch (IOException e) {
                        Log.println(Log.ERROR,"RESET_ERROR", Objects.requireNonNull(e.getMessage()));
                    }

                    Toast toast = Toast.makeText(getApplicationContext(),"The Quiz has been reset.", Toast.LENGTH_LONG);
                    toast.show();
                }
            });
        } catch (Exception e) {
            Log.println(Log.ERROR,"SUBMIT_ERROR", Objects.requireNonNull(e.getMessage()));
        }

        try {
            //Listener to change the display when the selected radio button is changed.
            questionRadioGroup.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener()
            {
                @Override
                public void onCheckedChanged(RadioGroup group, int checkedId) {
                    RadioButton button = questionRadioGroup.findViewById(checkedId);

                    button.setBackgroundColor(Color.rgb(123, 141, 147));

                    //Makes sure that only the currently selected button has a grey background.
                    for (RadioButton otherButton : listOfRadioButtons) {

                        if (button == otherButton) continue;
                        otherButton.setBackgroundColor(Color.WHITE);
                    }
                }
            });
        } catch (Exception e) {
            Log.println(Log.ERROR,"QUESTION_LISTENER_ERROR", Objects.requireNonNull(e.getMessage()));
        }


    }

    //Method to sort the quiz input file.
    private void sortQuestionsAndAnswers() throws IOException {

        //Gets a bufferedReader to access a text file in the assets folder.
        BufferedReader reader = new BufferedReader(new InputStreamReader(getAssets().open("Quiz.txt")));

        String line;
        String[] tempArray;

        try {
            //Loops while there are more lines in the file.
            while ((line = reader.readLine()) != null) {
                tempArray = line.split("~");

                definitions.add(tempArray[0]);

                //Puts the temp array question values into the HashMap with the definition as the key.
                questionsHash.put(tempArray[0], Arrays.copyOfRange(tempArray, 1, tempArray.length));

            }
            Collections.shuffle(definitions);
        } catch (IOException e) {
            Log.println(Log.ERROR,"IO_ERROR", Objects.requireNonNull(e.getMessage()));
        }

    }

    //Method to generate a new question everytime it is called until no questions remain.
    private void generateQuestion()
    {

        //If there are no more questions, then end the quiz.
        if (definitions.isEmpty()) {
            completeQuiz();
            return;
        }


        TextView question = findViewById(R.id.questionText);
        question.setText(definitions.get(0));

        //Gets the String Array from the hash using the definition, then removes the definition.
        String[] answerArray = questionsHash.get(definitions.get(0));
        definitions.remove(0);

        if (answerArray != null)
        {

            try {
                //Shuffles the array
                Collections.shuffle(Arrays.asList(answerArray));
                for (int i = 0; i < answerArray.length; i++) {

                    //Checks each entry for the correct answer which has a * in the string.
                    //Removes the * and then marks down the string for later use.
                    if (answerArray[i].contains("*")) {
                        answerArray[i] = answerArray[i].replace("*", "");
                        correctAnswer = answerArray[i];
                    }
                    listOfRadioButtons.get(i).setText(answerArray[i]);
                }
            } catch (Exception e) {
                Log.println(Log.ERROR,"QUESTION_DISPLAY_ERROR", Objects.requireNonNull(e.getMessage()));
            }


        }
    }

    private void completeQuiz()
    {
        Intent intent = new Intent(QuizActivity.this, CompleteActivity.class);
        Bundle extras = new Bundle();
        extras.putInt("totalCorrect", totalCorrect);
        extras.putInt("totalQuestions", totalCompletedQuestions);
        extras.putString("userName", userName.getText().toString());
        intent.putExtras(extras);

        startActivity(intent);
    }
}
