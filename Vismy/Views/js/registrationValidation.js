$(document).ready(function () {
    $("#registrationForm").submit(function (e) {
        e.preventDefault();

        var email = $("#email").val();
        var nickname = $("#nickname").val();
        var password = $("#password").val();
        var emailPattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;
        var success = true;

        $(".invalid-feedback").remove();
        if (password.length >= 6) {
            $("#password").removeClass("is-invalid");
            $("#password").addClass("is-valid");
        }
        else {
            $("#password").addClass("is-invalid").after('<span class="invalid-feedback">Password is too short. Please, add 6+ characters password</span>');
            success = false;
        }

        if (nickname.length >= 1) {
            $("#nickname").removeClass("is-invalid");
            $("#nickname").addClass("is-valid");
        }
        else {
            $("#nickname").addClass("is-invalid").after('<span class="invalid-feedback">Enter a valid nickname</span>');
            success = false;
        }

        if (email.length >= 1 && emailPattern.test(email)) {
            $("#email").removeClass("is-invalid");
            $("#email").addClass("is-valid");
        }
        else {
            $("#email").addClass("is-invalid").after('<span class="invalid-feedback">Enter a valid email</span>');
            success = false;
        }

        if (success) {
            $("#email").prop("disabled", true);
            $("#nickname").prop("disabled", true);
            $("#password").prop("disabled", true);
            $("#register").prop("disabled", true);
        }
    });
});