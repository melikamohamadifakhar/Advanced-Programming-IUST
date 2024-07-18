using System.ComponentModel.DataAnnotations;

namespace P8.Shared{
    public class Clothe{
        [Required]
        [Range(1, 99999999999)]
        public int Price{get; set;}
        [Required]
        public string Name{get; set;}
        [Required]
        public int Id{get; set;}
        [Required]
        public string Color{get; set;}
        
        public string Category{get; set;}
        [Required]

        public int Count{get; set;}
        public string Source{get; set;}
        public override string ToString()
        {
            return $"{this.Name}, {this.Id}, {this.Price}, {this.Color}";
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
        public override bool Equals(object obj)
        {
            var other = obj as Clothe;
            if(obj==null)
                return false;
            return this.Id==other.Id;
        }
        public void SetValue(Clothe other){
            this.Color = other.Color;
            this.Name = other.Name;
            this.Price = other.Price;
        }
    }
}
