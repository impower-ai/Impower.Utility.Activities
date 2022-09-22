# Impower.Utility.DataTable
Activity pack for working with DataTable elements

# Activities
## DataRowToDictionary
Activity that takes in a DataRow and converts it to a Dictionary of String, Object.
### Arguments
- in_DataRowInput - DataRow to Convert
- out_Dictionary - Created Dictionary

## DataRowToTypedDictionary
Activity that takes in a DataRow and converts it to a Typed Dictionary with a type you specify.
### Arguments
- in_DataRowInput - DataRow to Convert
- in_DefaultValue - Default type to convert values that cannot convert
- out_Dictionary - Created Typed Dictionary

# Extension Methods
This acitivty set comes with a couple of DataTable and related extension methods.
## DataRow#ToDictionary(T defaultValue)
Method for converting from a DataRow directly to a dictionary of string, object.

## DataRow#ToTypedDictionary<T>(T defaultValue)
Method for converting from DataRow to a typed dictionary.
### Examples
* CreatedTable.Rows(0).ToTypedDictionary(Of String)(Nothing)
