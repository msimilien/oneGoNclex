function checkAnswer(index, isCorrect, questionID) {
    if (isCorrect) {
        $("#lblCorrect").fadeIn();
        $("#lblAnswerExplanation").fadeIn();
        $("#lblIncorrect").css("display", "none");
        setTimeout(function () {
            $("#txtQuestionsAnswered").val(questionID + "|1" + "|" + index);
        }, 100);
    } else {
        $("#lblIncorrect").fadeIn();
        $("#lblCorrect").css("display", "none");
        $("#lblAnswerExplanation").css("display", "none");
        setTimeout(function () {
            $("#txtQuestionsAnswered").val(questionID + "|0" + "|" + index);
        }, 100);
    }
}