function getValues() {
    var text = "";
    var firstName = document.getElementsByName("firstname")[0].value;
    if (!firstName) {
        document.getElementById("schoolvalues").innerHTML = "";
        alert("Error: Please enter a first name.");
        return;
    }
    var lastName = document.getElementsByName("lastname")[0].value;
    if (!lastName) {
        document.getElementById("schoolvalues").innerHTML = "";
        alert("Error: Please enter a last name.");
        return;
    }

    text += "Name: " + firstName + " " + lastName + "<br />";
    var age = document.getElementsByName("age")[0].value;
    if (!age) {
        document.getElementById("schoolvalues").innerHTML = "";
        alert("Error: Please enter an age.");
        return;
    }
    if (age < 0) {
        document.getElementById("schoolvalues").innerHTML = "";
        alert("Error: You're a negative age? Come on. At least pretend you were just born.");
        return;
    }
    text += "Age: " + age + "<br />";
    var yearinschool = document.getElementsByName("yearinschool")[0].getAttribute("value");
    text += "Year in School: " + yearinschool;
    document.getElementById("schoolvalues").innerHTML = text;
}