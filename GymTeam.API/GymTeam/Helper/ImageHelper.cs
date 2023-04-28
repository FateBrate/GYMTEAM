namespace GymTeam.Helper
{
    public static  class ImageHelper
    {
        public static byte[] GetImage(this string image)
        {
            if(image.Contains(','))
                image=image.Split(',')[1];
            return System.Convert.FromBase64String(image);
        }
    }
}
