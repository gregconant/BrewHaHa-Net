(function() {
  window.CreateContest = function() {
    var $continueButton, $existingContests, hideContinueButton, showContinueButton;

    $continueButton = $("#continue-button");
    $existingContests = $(".existing-contests");
    hideContinueButton = function() {
      return $continueButton.hide();
    };
    showContinueButton = function() {
      return $continueButton.show();
    };
    $continueButton.hide();
    return $existingContests.change(function() {
      if ($existingContests.find(":selected").val() === 0) {
        hideContinueButton();
      } else {
        showContinueButton();
      }
      return $continueButton.attr("href", "/Contest/Load/" + $existingContests.find(":selected").val());
    });
  };

  jQuery(function() {
    return $(".existing-contests").each(window.CreateContest);
  });

}).call(this);
