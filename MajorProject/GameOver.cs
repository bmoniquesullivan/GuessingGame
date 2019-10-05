
using Android.App;
using Android.OS;
using Android.Widget;


namespace MajorProject
{
    [Activity(Label = "GameOver")]
    public class GameOver : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Creatin our application here
            SetContentView(Resource.Layout.GameOver);
            TextView text_lastsort = FindViewById<TextView>(Resource.Id.text_lastsort);
            TextView text_lasttry = FindViewById<TextView>(Resource.Id.text_lasttry);
            Button cmd_end = FindViewById<Button>(Resource.Id.cmd_end);

            //Update data for Textviews
            int sorted = int.Parse(Intent.GetStringExtra("sorted"));
            int tries = int.Parse(Intent.GetStringExtra("tries"));

            //Put the Number I was thinking on our TextView
            text_lastsort.Text = "The number I was thinking was: " + sorted.ToString();

            //Show the number of Tries on our second TextView
            if (tries == 0)
            {
                text_lasttry.Text = "You got my number on your first Try. Nice Job!";
            }
            else
            {
                text_lasttry.Text = "You've tried to guess my Number " + tries.ToString() + " times until you get it right.";
            }

            //Click Event for cmd_end
            cmd_end.Click += delegate
             {
                 this.Finish();
             };
        }
    }
}