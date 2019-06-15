var GigsController = function (attendanceService, followingService) {

    var button;

    var init = function () {
        $(".js-toggle-attendance").click(toggleAttendance);
        $(".js-toggle-following").click(toggleFollowing);
    }

    var toggleFollowing = function (e) {
        e.preventDefault();
        var button = $(e.target);
        if (button.hasClass("btn-default"))
            followingService.createFollowing(button.attr("data-artist-id"), doneFollowing, fail)
        else
            followingService.deleteFollowing(button.attr("data-artist-id"), doneFollowing, fail)
    };

    var toggleAttendance = function (e) {
        e.preventDefault();
        button = $(e.target);
        if (button.hasClass("btn-default"))
            attendanceService.createAttendance(button.attr("data-gig-id"), done, fail);
        else
            attendanceService.deleteAttendance(button.attr("data-gig-id"), done, fail);
    };

    var fail = function () {
        alert("Something Failed");
    };

    var done = function () {
        var text = (button.text == "Going") ? "Going ?" : "Going";
        button.toggleClass("btn-default").toggleClass("btn-info").text(text);
    }

    var doneFollowing = function () {
        var text = (button.text == "Following") ? "Follow" : "Following";
        button.text(text);
    }

    return {
        init: init
    }


}(AttendanceService, FollowingService);

