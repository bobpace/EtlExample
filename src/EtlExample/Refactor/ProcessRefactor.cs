using System.Collections.Generic;
using System.Data.SqlClient;
using Rhino.Etl.Core;

namespace EtlExample.Refactor
{
    public class ProcessRefactor
    {
        readonly CachingPropertyTypeValuesProvider propertyTypeValueProvider;

        public ProcessRefactor()
        {
            propertyTypeValueProvider =
                new CachingPropertyTypeValuesProvider(new DefaultPropertyTypeValuesProvider());
        }

        public IEnumerable<SqlCommand> Execute(Row row)
        {
            int addressId = Address.Load(row["locationIdentifier"].ToString()).AddressId;
            var builder = new PropertyTypeCommandBuilder(propertyTypeValueProvider, addressId, row);
            return builder.GetPropertyTypeCommandsFor<AddressPropertyType>(
                (id, propertyTypeId, propertyValue) =>
                {
                    var command = new SqlCommand
                    {
                        CommandText =
                            "INSERT INTO AddressProperties(AddressID, AddressPropertyTypeID, PropertyValue) VALUES(@addressId, @addressPropertyTypeId, @propertyValue)"
                    };

                    command.Parameters.AddWithValue("addressId", id);
                    command.Parameters.AddWithValue("addressPropertyTypeId", propertyTypeId);
                    command.Parameters.AddWithValue("propertyValue", propertyValue);
                    return command;
                });
        }
    }

    //public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
    //{
    //    foreach (var dic in _fileData.Rows.Values)
    //    {
    //        int id = Address.Load(dic["locationIdentifier"]).AddressID;

    //        Row r = CreateRow(dic["serviceArea"], id, Constants.AddressPropertyType.ServiceArea);
    //        if (r != null)
    //        {
    //          yield return r;
    //        }
    //        r = CreateRow(dic["locationDescription"], id, Constants.AddressPropertyType.LocationDescription);
    //        if (r != null)
    //        {
    //          yield return r;
    //        }
    //        r = CreateRow(dic["locationUrl"], id, Constants.AddressPropertyType.LocationUrl);
    //        if (r != null)
    //        {
    //          yield return r;
    //        }
    //        r = CreateRow(dic["locationLogoName"], id, Constants.AddressPropertyType.LocationLogoName);
    //        if (r != null)
    //        {
    //          yield return r;
    //        }
    //        r = CreateRow(dic["locationPhotoNames"], id, Constants.AddressPropertyType.LocationPhotoNames);
    //        if (r != null)
    //        {
    //          yield return r;
    //        }
    //        r = CreateRow(dic["keywords"], id, Constants.AddressPropertyType.Keywords);
    //        if (r != null)
    //        {
    //          yield return r;
    //        }
    //    }
    //}

    //private Row CreateRow(string val, int id, Constants.AddressPropertyType type)
    //{
    //   if (string.IsNullOrEmpty(val) || val.ToLower() == "null") return null;
    //   Row r = new Row();
    //   r["AddressID"] = id;
    //   r["AddressPropertyTypeID"] = (int)type;
    //   r["PropertyValue"] = val;
    //   return r;
    //}
}