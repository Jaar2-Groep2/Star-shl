<template>
    <div class="login"></div>

    <div class="plaatje">
        <img src="../assets/star-shl.jpg" />
    </div>

    <div class="main_box">
        <div class="box">
            <div class="heading">
                <h1>Login</h1>
            </div>
            <div class="form">
                <input type="text" name="username" v-model="input.username" placeholder="Gebruikersnaam" />
                <input type="password" name="password" v-model="input.password" placeholder="Wachtwoord" />
            </div>
            <button class="btn" v-on:click="login()">Login</button>
        </div>
    </div>

</template>

    <script>
        import axios from 'axios'
        export default {
            name: 'Login',
            emits: ["authenticated", "setAuthenticated"],
            data() {
                return {
                    input: {
                        username: "",
                        password: ""
                    },
                    loginauth: false
                }
            },
            methods: {
                LoginCall(username, password) {
                    axios.get(("http://localhost:5000/api/login/"+username+'/'+password))
                        .then((response) => {
                            this.loginauth = response.data;
                            console.log(username + ' ' + password + ' ' + response.data + ' ' + this.loginauth);
                            //console.log("Result: " + response.data);                           
                        })
                        .catch(function (error) {
                            console.log(error);
                            alert(error);
                        });

                },
                login() {
                    //method call here
                    //iets
                    if (this.input.username != "" && this.input.password != "") {
                        this.LoginCall(this.input.username, this.input.password);
                        //console.log(this.loginauth);

                        this.loginactual(this.loginauth);


                    } else {
                        console.log("A username and password must be present");
                    }
                },
                loginactual(auth) {
                    console.log(auth);
                    //this.login();
                    if (auth) {
                        this.$emit("authenticated", true);
                        this.$router.replace({ name: "Secure" });   //changes webpage to /Secure
                    } else {
                        //window.alert("The username and / or password is incorrect");
                        console.log("The username and / or password is incorrect");
                    }
                }
            }
        }
    </script>

    <style scoped>
        body {
            background: #142d49;
            width: 100%;
            height: 100vh;
            overflow: hidden;
        }
        .plaatje {
            max-width: 100%;
            height: auto;
        }
        img {

            vertical-align: middle;
            border-style: none;
            width: 800px;
            max-width: 80%;
        }
        .main_box {
            margin-top: 200px;
            position: absolute;
            top: 50%;
            left: 50%;
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
            width: 800px;
            max-width: 90%;
            height: 350px;
            /* padding: 1rem; */
            position: relative;
            background: #79b9d5;
            padding: 3px;
            border-radius: 20px;
        }

        .box {
            background: #142d49;
            color: white;
            padding: 2rem;
            display: flex;
            flex-direction: column;
            align-items: center;
            border-radius: 20px;
            height: 100%;
        }

        h1 {
            font-size: 50px;
            margin-bottom: 10px;
        }

        .heading {
            margin-bottom: 20px;
            margin-top: -10px
        }

        .form {
            margin: 0;
            position: absolute;
            top: 50%;
            left: 50%;
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
        }

        .form input {
            margin: 5px 0;
            background-color: transparent;
            border: none;
            border-bottom: 1px solid white;
            color: white;
            text-align: center;
        }

        .form input ::placeholder {
            color: gray;
        }

        .int {
            border-radius: 5px;
            font-size: 17px;
            margin-bottom: 10px;
            border-color: red;
        }

        .btn {
            font-size: 20px;
            color: white;
            background: #e7334c;
            border-color: #121212;
            margin-top: 100px;
        }

        #login {
            width: 500px;
            border: 1px solid #CCCCCC;
            background-color: white;
            margin: auto;
            margin-top: 200px;
            padding: 20px;
        }
        img {
            vertical-align: middle;
            border-style: none;
            width: 60%;
            width: 800px;
            max-width: 90%;
        }
    </style>
