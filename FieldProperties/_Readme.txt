This namespace contains the data api equivalents for fields, ergo, if it doesn't have a CustomField
it won't be converted by Diamond. The only fields that are included are the ones that are mapped 
using the FieldTypes.config. System and Developer types are similarly excluded due to their limited
utility when dealing with presentation, but feel free to add support for them.

Fields
======================

------------
Simple Types
------------
CheckboxField -> CheckboxProperty
DateField -> DateProperty
FileField -> FileProperty
ImageField -> ImageProperty
HtmlField -> HtmlProperty 
TextField -> TextProperty
WordDocumentField -> WordDocumentProperty

----------
List Types
----------
MultilistField -> MultilistProperty
ValueLookupField -> ValueLookupProperty
GroupedDroplinkField -> GroupedDroplinkProperty
GroupedDroplistField -> GroupedDroplistProperty
NameValueListField -> NameValueListProperty

----------
Link Types
----------
ReferenceField -> ReferenceProperty
LinkField -> LinkProperty

VersionLinkField Is not covered because it is reserved for Sitecore


