namespace DiskusiinWebAPI.Models
{
    public class Rentings
    {
        public int Id { get; set; }
        public int Room_Id { get; set; }
        public int User_Id { get; set; }
        public string Keperluan { get; set; }
        public string Tanggal { get; set; }
        public string Mulai { get; set; }
        public int Durasi { get; set; }
        public int Jumlah_Orang { get; set; }
    }
}
