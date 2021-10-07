<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HMS.Login" %>

<!DOCTYPE html>
<html>

        <head>
            <title> Welcome</title>
            <link rel="icon" type="image/ico" href="Ruwanalogo.png">
        </head>
<style>
html {
			font-family: Arial;
			display: inline-block;
			margin: 10px auto;
			height: 100%;
		}

body{
	margin:0;
	color:#d4af37;
	background:#141e30;
	  font-family: sans-serif;
}
*,:after,:before{box-sizing:border-box}
.clearfix:after,.clearfix:before{content:'';display:table}
.clearfix:after{clear:both;display:block}
a{color:inherit;text-decoration:none}

.login-wrap{
	padding:50px;
	width:100%;
	margin:auto;
	max-width:525px;
	min-height:750px;
	position:relative;
	background-color:url(https://ichef.bbci.co.uk/news/976/cpsprodpb/10B7B/production/_107157486_students8.jpg) no-repeat center;

}
.login-html{
	width:100%;
	height:100%;
	position:absolute;
	padding:90px 70px 50px 70px;
	background:rgba(0,0,0,.5);
}
.login-html .sign-in-htm,
.login-html .sign-up-htm{
	top:0;
	left:0;
	right:0;
	bottom:0;
	position:absolute;
	transform:rotateY(180deg);
	backface-visibility:hidden;
	transition:all .4s linear;
}
.login-html .sign-in,
.login-html .sign-up,
.login-form .group .check{
	color:white;
	display:none;
}
.login-html .tab,
.login-form .group .label,
.login-form .group .button{
	text-transform:uppercase;
}
.login-html .tab{
	font-size:22px;
	margin-right:15px;
	padding-bottom:5px;
	margin:0 15px 10px 0;
	display:inline-block;
	border-bottom:2px solid transparent;
}
.login-html .sign-in:checked + .tab,
.login-html .sign-up:checked + .tab{
	color:#fff;
	border-color:#d4af37;
}
.login-form{
	min-height:345px;
	position:relative;
	perspective:1000px;
	transform-style:preserve-3d;
}
.login-form .group{
	margin-bottom:15px;
}
.login-form .group .label,
.login-form .group .input,
.login-form .group .button{
	width:100%;
	color:#fff;
	display:block;
}
.login-form .group .input,
.login-form .group .button{
	border:none;
	padding:15px 20px;
	border-radius:25px;
	background:rgba(255,255,255,.1);
}
.login-form .group input[data-type="password"]{
	text-security:circle;
	-webkit-text-security:circle;
}
.login-form .group .label{
	color:white;
	font-size:12px;
}
.login-form .group .button{
	background:#d4af37;
}
.login-form .group label .icon{
	width:15px;
	height:15px;
	border-radius:2px;
	position:relative;
	display:inline-block;
	background:rgba(255,255,255,.1);
}
.login-form .group label .icon:before,
.login-form .group label .icon:after{
	content:'';
	width:10px;
	height:2px;
	background:#fff;
	position:absolute;
	transition:all .2s ease-in-out 0s;
}
.login-form .group label .icon:before{
	left:3px;
	width:5px;
	bottom:6px;
	transform:scale(0) rotate(0);
}
.login-form .group label .icon:after{
	top:6px;
	right:0;
	transform:scale(0) rotate(0);
}
.login-form .group .check:checked + label{
	color:#fff;
}
.login-form .group .check:checked + label .icon{
	background:#1161ee;
}
.login-form .group .check:checked + label .icon:before{
	transform:scale(1) rotate(45deg);
}
.login-form .group .check:checked + label .icon:after{
	transform:scale(1) rotate(-45deg);
}
.login-html .sign-in:checked + .tab + .sign-up + .tab + .login-form .sign-in-htm{
	transform:rotate(0);
}
.login-html .sign-up:checked + .tab + .login-form .sign-up-htm{
	transform:rotate(0);
}

.hr{
	height:2px;
	margin:60px 0 50px 0;
	background:rgba(255,255,255,.2);
}
.foot-lnk{
	text-align:center;
}
#text {display:none;color:red;
font-size:small }
.para
{
	display: block;
  margin-left: auto;
  margin-right: auto;
  color:white;
  width: 85%;
}
.alert {
  padding: 20px;
  background-color: #ff9800;
  color: white;
}

.closebtn {
  margin-left: 15px;
  color: white;
  font-weight: bold;
  float: right;
  font-size: 22px;
  line-height: 20px;
  cursor: pointer;
  transition: 0.3s;
}

.closebtn:hover {
  color: black;
}


</style>
<body>
        <div class="login-wrap">
                <div class="login-html">
                    <input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Log In</label>
                    <input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab">Sign Up</label>
                    <div class="login-form">
							
                        <div class="sign-in-htm">
                            <div class="group">
                                <label for="user" class="label">Username</label>
								<input id="name" type="text" class="input" name="name" required="" oninvalid="this.setCustomValidity('Please Enter Your Name')" 
								oninput="setCustomValidity('')"> 
                            </div>
                            <div class="group">
                                <label for="pass" class="label">Password</label>
								<input id="password" type="password" class="input" data-type="password" name="pass" required="" oninvalid="this.setCustomValidity('Please Enter Your Password')" 
								oninput="setCustomValidity('')"  ><p id="text">WARNING! Caps lock is ON.</p>
								
                            </div>
                            <div class="group">
                                <input id="check" type="checkbox" class="check" checked>
                                <label for="check"><span class="icon"></span> Keep me Signed in</label>
                            </div>
                            <div class="group">
                                <input type="button" id="btnLogin" class="button" value="Log In" onclick="btnLogin_Click">
								
                            </div>
                            <div class="hr"></div>
                            <div class="foot-lnk">
								<a href="#forgot" type="button" style="color:white;"onclick="location.href='forgetpassword.php'" >Forgot Password?</a>
								
								
								<p> <img src="C:\Users\sachi\Downloads\HMS\SOAPS\Theme\dist\img\sky gold LOGO 2 png.png" alt="Skyblue" style="float:inherit;width:100px;height:60px;color:white;"></p>
								<div class="para">
								<p> &copy; 2021 Team SkyBlue | All Rights Reserved</p>
								</div>
							</div>
							
						</div>
						<form action="sign.php" method="POST">
                        <div class="sign-up-htm">
                            <div class="group">
								<br>
						<div class="alert">
  						<span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span> 
 						 <strong>WARNING!</strong> You dont have access to Register as an Admin. Please Contact Program Office
						</div>
								
                                <!-- <label for="user" class="label">Username</label>
                                <input id="user" type="text" class="input" name="name" required="" oninvalid="this.setCustomValidity('Please Enter Your Username')" 
								oninput="setCustomValidity('')">
                            </div>
                            <div class="group">
                                <label for="pass" class="label">Password</label>
								<input id="pass" type="password" class="input" data-type="password" name="pass" minlength="8" required="" oninvalid="this.setCustomValidity('Please Enter Your Password')" 
								oninput="setCustomValidity('')"> 
								
                            </div>
                           
                            <div class="group">
                                <label for="pass" class="label">Re Enter Password</label>
                                <input id="pass" type="password" class="input" name="email" required="" oninvalid="this.setCustomValidity('Please Enter Your Email Address')" 
								oninput="setCustomValidity('')">
							</div>
							<div class="group">
									<label for="pass" class="label">Employee ID</label>
									<input id="pass" type="text" class="input" name="country" required="" oninvalid="this.setCustomValidity('Please Enter Your Country')" 
									oninput="setCustomValidity('')">
							</div>
						
                            <div class="group">
                                <input type="submit" class="button" value="Sign Up">
                            </div>
                            <div class="hr"> -->
							<br>
                            <div class="foot-lnk">
								<label for="tab-1" style="color:white">Already Member?</a>
									</label>
									 	<p> <img src="C:\Users\sachi\Downloads\HMS\SOAPS\Theme\dist\img\sky gold LOGO 2 png.png" alt="Skyblue" style="float:inherit;width:100px;height:60px;color:white;"></p>
								<div class="para">
								<p> &copy; 2021 Team SkyBlue | All Rights Reserved</p>
                            </div>
                        </div>
					</div>
					</form>
                </div>
            </div>

            <script>
 /* function validateform()
  {
	  var x=document.forms["log"]["name"].value;
	  if(x=="")
	  {
		  alert("Name Should Be Enter");
		  return false;
	  }
  }*/
  var input = document.getElementById("pass");
var text = document.getElementById("text");
input.addEventListener("keyup", function(event) {

if (event.getModifierState("CapsLock")) {
    text.style.display = "block";
  } else {
    text.style.display = "none"
  }
});
            </script>
</body>
</html>