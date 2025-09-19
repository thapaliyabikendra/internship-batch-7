using Filehandeling;
InfoAboutText file=new InfoAboutText();
file.TextProcessing();
LogingHelper logingHelper = new LogingHelper();
logingHelper.Logger("Error warning", "Error");
CsvToJsonConverter converter = new CsvToJsonConverter();
converter.Convert();