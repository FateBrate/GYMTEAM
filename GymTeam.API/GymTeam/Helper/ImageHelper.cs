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

        public static byte[]? GetImage(this IFormFile file)
        {
            if (file == null)
                return null;

            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }
            return fileBytes;
        }
    }
}
