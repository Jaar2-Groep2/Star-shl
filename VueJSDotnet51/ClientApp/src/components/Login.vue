<template>
        <div class="login"></div>
        <img src="../assets/star-shl.jpg" />
        <div class="main_box">
            <div class="box">
                <div class="heading">
                    <h1>Login</h1>
                </div>
                <div class="form">
                    <input type="text" name="username" v-model="input.username" placeholder="Username" />
                    <input type="password" name="password" v-model="input.password" placeholder="Password" />
                </div>
                <button class="btn" v-on:click="login()">Login</button>
            </div>
        </div>
    </template>

    <script>
        export default {
            name: 'Login',
            emits: ["authenticated", "setAuthenticated"],
            data() {
                return {
                    input: {
                        username: "",
                        password: ""
                    }
                }
            },
            methods: {
                login() {
                    if (this.input.username != "" && this.input.password != "") {
                        //if (this.input.username == this.$parent.mockAccount.username && this.input.password == this.$parent.mockAccount.password) {
                            //this.$emit("authenticated", true);
                            //this.$router.replace({ name: "Secure" });                                 
                        if (this.input.username == "admin" && this.input.password == "admin") {
                            this.$emit("authenticated", true);
                            this.$router.replace({ name: "Secure" });
                        } else {
                            console.log("The username and / or password is incorrect");
                        }
                    } else {
                        console.log("A username and password must be present");
                    }
                }
            }
        }
    </script>

    <style scoped>
        body {
            background: radial-gradient(rgb(122, 122, 122), rgb(59, 59, 59));
            width: 100%;
            height: 100vh;
            overflow: hidden;
        }

        .main_box {
            margin: 0;
            position: absolute;
            top: 50%;
            left: 50%;
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
            max-width: 350px;
            height: 350px;
            /* padding: 1rem; */
            position: relative;
            background: linear-gradient(to right, red, purple);
            padding: 3px;
            border-radius: 20px;
        }

        .box {
            background: #222;
            color: white;
            padding: 2rem;
            display: flex;
            flex-direction: column;
            align-items: center;
            border-radius: 20px;
            height: 81.5%;
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

        .int {
            border-radius: 5px;
            font-size: 17px;
            margin-bottom: 10px;
            border-color: red;
        }

        .btn {
            font-size: 20px;
            color: white;
            background: red;
            border-color: red;
            margin-top: 80px;
        }

        #login {
            width: 500px;
            border: 1px solid #CCCCCC;
            background-color: #FFFFFF;
            margin: auto;
            margin-top: 200px;
            padding: 20px;
        }
    </style>
