
using Android.App;
using Android.OS;
using Android.Widget;
using System;
using Android.Content;

// Created by Barbara Sullivan and Makafui Naaman
// Class - Mobile App Development - 40830
// This game was created by us and not copied

namespace MajorProject
{
    [Activity(Label = "MainGame", MainLauncher = true, Icon = "@drawable/thinking")]
    public class MainGame : Activity
    {
        TextView text_tries;
        EditText edit_number;
        Button cmd_guess;
        Button cmd_restart;


        //Integers
        int number_sort;
        int number_tries;

        //----------------------------------------------



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Creating our application here
            SetContentView(Resource.Layout.MainGame);

            //Getting widgets
            text_tries = FindViewById<TextView>(Resource.Id.text_tries);
            edit_number = FindViewById<EditText>(Resource.Id.edit_number);
            cmd_guess = FindViewById<Button>(Resource.Id.cmd_guess);
            cmd_restart = FindViewById<Button>(Resource.Id.cmd_restart);




            Cmd_restart_Click(this, EventArgs.Empty);

            //Event Click from Button GUESS and RESTART GAME
            cmd_guess.Click += Cmd_guess_Click;
            cmd_restart.Click += Cmd_restart_Click;

        }

        private void Cmd_restart_Click(object sender, EventArgs e)
        {
            //Insert the starting configs for each game
            //Start the game
            //Sort a number
            Random rnd = new Random();
            number_sort = rnd.Next(0, 100);

            //Strating the Tries
            number_tries = 0;

            edit_number.Text = "";
            text_tries.Text = "Number of Tries: 0";
        }

        private void Cmd_guess_Click(object sender, EventArgs e)
        {
            //Checking the number typed vs number sorted

            //Check to see if any number was inserted
            if (edit_number.Text == "") return;

            //Check if the number typed is equal, higher or lower than number sorted
            int number_typed = int.Parse(edit_number.Text);
            string message;

            if (number_typed < number_sort)
            {
                //Show a message saying the number typed is lower than the number I'm guessing
                message = "The number you typed is lower than the number I'm thinking. Try again!";
                NumberOfTries();

            }
            else if (number_typed > number_sort)
            {
                //Show a message saying the number typed is higher than the number I'm guessing
                message = "The number you typed is higher than the number I'm thinking. Try again!";
                NumberOfTries();
            }
            else
            {
                //Open activity Game Over and show the result
                var finalactivity = new Intent(this, typeof(GameOver));

                //transfer info from number sorted and number of tries
                finalactivity.PutExtra("sorted", number_sort.ToString());
                finalactivity.PutExtra("tries", number_tries.ToString());

                StartActivity(finalactivity);
                return;
            }

            AlertDialog.Builder box = new AlertDialog.Builder(this);
            box.SetTitle("GUESS THE NUMBER");
            box.SetMessage(message);
            box.SetPositiveButton("OK", delegate { });
            box.SetCancelable(false);
            box.Show();
        }

        //----------------------------------------------

        private void NumberOfTries()
        {
            //Update the number of tries textbox
            number_tries++;
            text_tries.Text = "Number of Tries: " + number_tries.ToString();
        }
    }
}