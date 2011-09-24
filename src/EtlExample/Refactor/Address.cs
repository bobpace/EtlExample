namespace EtlExample.Refactor
{
    public class Address
    {
        public int AddressId { get; set; }
        public static Address Load(string locationIdentifier)
        {
            return new Address { AddressId = 1 };
        }
    }
}