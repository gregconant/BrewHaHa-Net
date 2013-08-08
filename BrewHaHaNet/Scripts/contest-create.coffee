window.CreateContest = ->
  $continueButton = $("#continue-button")
  $existingContests = $(".existing-contests")
  hideContinueButton = -> 
    $continueButton.hide()

  showContinueButton = -> 
    $continueButton.show()

  $continueButton.hide()
  $existingContests.change ->
    if $existingContests.find(":selected").val() == 0 then hideContinueButton() else showContinueButton()
    $continueButton.attr("href", "/Contest/Load/" + $existingContests.find(":selected").val())


jQuery ->
  $(".existing-contests").each(window.CreateContest)