// Write your JavaScript code.

$(document).ready(function(){
    $('#button-add-sensor').on('click', addSensor);
});

function addSensor() {
    var sensor = new Object();
    var Name = $('#sensor-name').val();
    var alarmHI = $('#sensor-alarmHI').val();
    var alarmHIHI = $('#sensor-alarmHIHI').val();
    var alarmLO = $('#sensor-alarmLO').val();
    var alarmLOLO = $('#sensor-alarmLOLO').val();
    var maxValue = $('#sensor-MaxValue').val();
    var minValue = $('#sensor-MinValue').val();
    var logging = $('#sensor-Logging').val();
    var deadband = $('#sensor-Deadband').val();
    //var data = { "name": Name, "almHI": alarmHI, "almHIHI": alarmHIHI, "almLO": alarmLO, "almLOLO": alarmLOLO, "log": "0", "mxVal": maxValue, "mnVal": minValue, "dead": deadband };
    sensor.Name = Name;
    sensor.AlarmHI = parseFloat(alarmHI);
    sensor.AlarmHIHI = parseFloat(alarmHIHI);
    sensor.AlarmLO = parseFloat(alarmLO);
    sensor.AlarmLOLO = parseFloat(alarmLOLO);
    sensor.Logging = false;
    sensor.MaxValue = parseFloat(maxValue);
    sensor.MinValue = parseFloat(minValue);
    sensor.Deadband = parseFloat(deadband);

    $.ajax(
        {
            type: "POST",
            url: "AddNewSensor",
            data: JSON.stringify(sensor,"\t"),
            contentType: "text/plain",
            success: function (msg) {
                window.location = "/Home/Sensors";
            }
         });
   // $.post("/Home/AddNewSensor", data, function () {
   //     window.location = "/Home/Sensors";
  //  });
}