@Echo off
REM xsd.exe must be in the path and local directory should be the directory of this batch file
xsd Xacml\Schemas\xacml-core-v3-schema-wd-17.xsd /l:CS /n:Xacml.Schemas /c /o:Xacml\Schemas