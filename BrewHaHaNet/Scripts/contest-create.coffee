window.CreateContest = ->
  $("#continue-button").click  ->
    console.log("something")
    null
  null
  
jQuery ->
  $("#existing-contests").each(window.CreateContest)