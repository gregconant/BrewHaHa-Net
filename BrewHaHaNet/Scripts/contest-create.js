var BrewHaHa = BrewHaHa || { };

BrewHaHa.CreateContest = {
  init: function(index, value) {
    $("#continue-button").click(function() {
      console.log("something");
    });
  }
};

$(function () {
  $(".existing-contests").each(BrewHaHa.CreateContest.init);
});

