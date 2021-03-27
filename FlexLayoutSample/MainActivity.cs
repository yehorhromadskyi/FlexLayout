using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Com.Google.Android.Flexbox;

namespace FlexLayoutSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        readonly string Lorem = "Lorem ipsum dolor sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna consectetur";

        private RecyclerView recyclerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetAdapter(new Adapter(Lorem.Split(" ")));
            recyclerView.SetLayoutManager(new FlexboxLayoutManager(this));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class Adapter : RecyclerView.Adapter
    {
        private readonly string[] lorem;

        public override int ItemCount => lorem.Length;

        public Adapter(string[] lorem)
        {
            this.lorem = lorem;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is ViewHolder viewHolder)
            {
                viewHolder.TextView.Text = lorem[position];
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                                         .Inflate(Resource.Layout.recycler_view_item, parent, false);

            return new ViewHolder(itemView);
        }
    }

    public class ViewHolder : RecyclerView.ViewHolder
    {
        public ViewHolder(View itemView) : base(itemView)
        {
            TextView = itemView.FindViewById<TextView>(Resource.Id.textView);
        }

        public TextView TextView { get; private set; }
    }
}
