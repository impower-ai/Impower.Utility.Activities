# Impower.Utility.Queue

Activity set created to work with QueueItems and Queues overall.

# Activities
## Generate Queue Item
Activity for converting any even length IEnummerable of objects into a Queue Item that has its specific content set to your array.
* Example; {"hey", "there"} -> QueueItem with SpecificContent = Dictionary<string, object>(){{"hey", "there"}}

### Arguments
* in_Items - IEnumerable of Object that is of even length.
* out_QueueItem - QueueItem

## Get Typed Dictionary
Activity for Converting any Dictionary of type Dictionary<string, object> to a Dictionary of Dictionary<string, YourSpecifiedType>
#### Arguments
* in_Dictionary - Dictionary to convert
* in_DefaultValue - Type to place in the dictionary for values that could not be converted to provided type
* out_CleanDictionary - Dictionary that is typed as per your provided value

## Get Typed Dictionary From Queue Item
Wrapper for Get Typed Dictionary that takes in a QueueItem and Converts its SpecificContent.
### Arguments
* in_QueueItem - Queue item to take the Specific content of for conversion  
* in_DefaultValue - Type to place in the dictionary for values that could not be converted to provided type
* out_CleanDictionary - Dictionary that is typed as per your provided value


# Extension Methods
With this project, located in Impower.Utility.Utilities.Util is a couple of extension methods specific to this activity set.
## Dictionary<string, object>#ConvertedDictionary<T>(T defaultValue)
Method that allows you to call ConvertedDictionary on any Dictionary of String, Object. This can be used to convert any Dictionary outside of this activity set as well. Default value is returned when conversion not possible.
### Examples
* Queue Item Specific Content to Dictionary Of String, String
    * YourQueueItem.SpecificContent().ConvertedDictionary(Of String)(Nothing) -> Dictionary<string, string>
        * Now all values that can be converted to a string have been, all else are Nothing.

## Object#ConvertedValue<T>(T defaultValue)
Extension method for any Object, which can be used to convert any object to the IConvertible counterpart. Default value is returned when conversion not possible.
### Examples
* String "False" converted to actual Boolean
    * "False".ConvertedValue(Of Boolean)(Nothing) -> False

## QueueItem#ConvertedSpecificContent<T>(T defaultValue)
Extension method for UiPath.Core.QueueItem that automatically grabs and converts the Specific Content to a typed dictionary of your specification.
### Examples
* QueueItem to Dictionary of String, string
    * QueueItem.ConvertedSpecificContent(Of String)(Nothing) -> Dictionary<string, string>
