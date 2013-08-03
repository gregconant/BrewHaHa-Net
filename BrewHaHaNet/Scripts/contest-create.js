(function() {
  window.CreateContest = function() {
    return console.log('creating contest');
  };

  jQuery(function() {
    return $("#create-contest").each(window.CreateContest);
  });

}).call(this);
