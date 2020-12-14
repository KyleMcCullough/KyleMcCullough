package com.example.quizbuilder;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class CompleteActivity extends AppCompatActivity {

    Button retryButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_complete);
        retryButton = findViewById(R.id.retryButton);

        report();

        retryButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Bundle previousExtras = getIntent().getExtras();

                Intent intent = new Intent(CompleteActivity.this, QuizActivity.class);
                Bundle extras = new Bundle();
                extras.putString("userName", previousExtras.getString("userName"));
                intent.putExtras(extras);
                startActivity(intent);
            }
        });
    }

    private void report() {
        TextView report = findViewById(R.id.reportTextView);

        Bundle extras = getIntent().getExtras();

        report.setText(String.format("You answered a total of %d questions, with %d correct answer(s).", extras.getInt("totalQuestions"), extras.getInt("totalCorrect")));
    }
}
