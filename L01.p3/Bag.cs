namespace L01.p3
{
    public class Bag
    {
        public Bag(int prop1, string prop2, double prop3)
        {
            Prop1 = prop1;
            Prop2 = prop2;
            Prop3 = prop3;
        }

        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
        public double Prop3 { get; set; }

        public override string ToString()
        {
            return $"{Prop1} {Prop2} {string.Format("{0:f}", Prop3)}";
        }
    }
}