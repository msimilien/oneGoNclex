$(function () {
    const maxValueMinute = "59";
    const minValueMinute = "00";

    setTimeout(function () {
        setInterval(function () {
            var timerLabel = $("#lblTimer").text();
            var resultClock = timerLabel.split(':');

            //Seconds
            if (resultClock[2] != minValueMinute) {
                var resultSeconds = parseInt(resultClock[2]) - 1;
                resultClock[2] = resultSeconds > 9 ? resultSeconds : "0" + resultSeconds;
                $("#lblTimer").text(resultClock[0] + ":" + resultClock[1] + ":" + resultClock[2]);

                if ($("#lblTimer").text() === "00:00:00")
                    $("#btnFinish").trigger("click");

                return;
            }

            //Seconds affect minutes
            if (resultClock[2] == minValueMinute && resultClock[1] != minValueMinute) {
                resultClock[2] = maxValueMinute;
                var resultMinutes = parseInt(resultClock[1]) - 1;
                resultClock[1] = resultMinutes > 9 ? resultMinutes : "0" + resultMinutes;
                $("#lblTimer").text(resultClock[0] + ":" + resultClock[1] + ":" + resultClock[2]);
                return;
            }

            //Minutes affect hours
            if (resultClock[2] == minValueMinute &&
                resultClock[1] == minValueMinute &&
                resultClock[0] != minValueMinute) {
                resultClock[2] = maxValueMinute;
                resultClock[1] = maxValueMinute;
                var resultHours = parseInt(resultClock[0]) - 1;
                resultClock[0] = resultHours > 9 ? resultHours : "0" + resultHours;
                $("#lblTimer").text(resultClock[0] + ":" + resultClock[1] + ":" + resultClock[2]);
                return;
            }
        }, 1000);
    }, 1000);
});
function checkAnswer(questionID, isCorrect, index) {
    if (isCorrect)
        $("#txtQuestionsAnswered").val(questionID + "|1" + "|" + index);
    else
        $("#txtQuestionsAnswered").val(questionID + "|0" + "|" + index);
}