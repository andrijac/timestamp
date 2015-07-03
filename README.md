# timestamp
Outputs date and time (depending on format) in plain text into clipboard and current output stream.

###Usage:

`timestamp [args]`

`args` are optionalWithout args it will output default format of date and time of local environment.

Use for help: <br>
`"-?", "/?", "--help", "-help", "help"`

For custom formatting, use any from the list [https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx](https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx).

###(Short) Predefined formats:

- `today`   dd-MM-yyyy
- `today-iso`   yyyy-MM-dd
- `today-us`   MM-yyyy-dd
- `raw`   yyyyMMddHHmmss
- `full`   dd-MM-yyyy_HH-mm-ss
- `full-iso`   yyyy-MM-dd_HH-mm-ss
- `full-us`   MM-yyyy-dd_HH-mm-ss

###Example:

`timestamp dd-MM-yyyy`<br>
`timestamp today`<br>
`timestamp full-us`<br>
`timestamp yyyy`<br>
`timestamp /?` <br>