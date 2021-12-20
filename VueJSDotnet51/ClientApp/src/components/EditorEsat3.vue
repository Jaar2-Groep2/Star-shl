<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link type="text/css" rel="stylesheet" href="css/materialize.min.css" media="screen,projection" />
    <div class="home">
        <div class="img">
            <img src="../assets/star-shl.jpg" />
        </div>
        <div>
            <router-link class="sezer btn" :to="{ name: 'EditorEsat1' }">Over Star-shl</router-link>
            <router-link class="sezer btn" :to="{ name: 'EditorEsat2' }">innovatie</router-link>
        </div>
        <div>
            <router-link class="sezer btn" :to="{ name: 'EditorEsat3' }">Vrijwilligersbeleid</router-link>
            <router-link class="sezer btn" :to="{ name: 'EditorEsat4' }">Kwaliteit</router-link>
        </div>
        <div class="edit_buttons">
            <div v-if="editor">
                <button @click="editor.chain().focus().undo().run()">
                    <div class="material-icons">undo</div>
                </button>
                <button @click="editor.chain().focus().toggleBold().run()" :class="{ 'is-active': editor.isActive('bold') }">
                    <div class="bub">bold</div>
                </button>
                <button @click="editor.chain().focus().toggleItalic().run()" :class="{ 'is-active': editor.isActive('italic') }">
                    italic
                </button>
                <button @click="editor.chain().focus().toggleStrike().run()" :class="{ 'is-active': editor.isActive('strike') }">
                    strike
                </button>
                <button @click="editor.chain().focus().toggleHeading({ level: 1 }).run()" :class="{ 'is-active': editor.isActive('heading', { level: 1 }) }">
                    h1
                </button>
                <button @click="editor.chain().focus().toggleHeading({ level: 2 }).run()" :class="{ 'is-active': editor.isActive('heading', { level: 2 }) }">
                    h2
                </button>
                <button @click="editor.chain().focus().toggleHeading({ level: 3 }).run()" :class="{ 'is-active': editor.isActive('heading', { level: 3 }) }">
                    h3
                </button>
                <button @click="editor.chain().focus().toggleHeading({ level: 4 }).run()" :class="{ 'is-active': editor.isActive('heading', { level: 4 }) }">
                    h4
                </button>
                <button @click="editor.chain().focus().toggleHeading({ level: 5 }).run()" :class="{ 'is-active': editor.isActive('heading', { level: 5 }) }">
                    h5
                </button>
                <button @click="editor.chain().focus().toggleBulletList().run()" :class="{ 'is-active': editor.isActive('bulletList') }">
                    bullet list
                </button>
            </div>
        </div>
        <div class="save_class">
            <editor-content :editor="editor" />
            <button class="btn_save" @click="saveInDB">opslaan</button>
        </div>
    </div>
    <footer>
        <p class="text-white">
            <strong>Etten-Leur</strong><br>
            Bredaseweg 165, 4872 LA<br>
            Postbus 228, 4870 AE<br>
            <br>
            <strong>Rotterdam</strong><br>
            Vlambloem 21, 3068 JE<br>
            Postbus 8661, 3009 AR<br>
        </p>
    </footer>
    <div>
        <!--<router-link class="info btn" :to="{ name: 'Info3' }">Vrijwilligersbeleid</router-link>
        <router-link class="info btn" :to="{ name: 'Info4' }">Kwaliteit</router-link>-->
    </div>
</template>

<script>
    import axios from 'axios'
    import { Editor, EditorContent } from '@tiptap/vue-3'
    import StarterKit from '@tiptap/starter-kit'

    export default {
        components: {
            EditorContent,
        },

        data() {
            return {
                editor: null,
                ContentArray: [],
                DBcontent: "",
                contentstring: ""
            }
        },

        methods: {
            GetContent() {
                axios.get("http://localhost:5000/api/content")
                    .then((response) => {
                        this.ContentArray = response.data;
                        this.contentstring = this.ContentArray[2]["content"];
                        this.editor.commands.setContent(this.contentstring);
                    })
                    .catch(function (error) {
                        console.log(error);
                        alert(error);
                    }
                    );

            },

            saveInDB() {
                const html = this.editor.getHTML();
                axios({
                    method: 'PUT',
                    url: 'http://localhost:5000/api/content/',
                    data: {
                        content: html,
                        id: 4
                    },
                    headers: {
                        'Content-Type': 'application/json',
                        "Access-Control-Allow-Origin": "*",
                        'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,PATCH,OPTIONS',
                        'Access-Control-Allow-Credentials': true
                    },
                }).then(function (response) {
                    console.log(response);
                    window.alert("Opgeslagen!");
                }).catch(function (error) {
                    console.log(error);
                    console.log(error.response);
                    alert(error);
                });
            },
        },

        mounted() {
            this.editor = new Editor(
                {

                    extensions: [
                        StarterKit,
                    ],
                    content: 'test '
                }),
                this.GetContent();
        },

        beforeUnmount() {
            this.editor.destroy()
        },
    }
</script>



<style>
    .btn:hover {
        opacity: 1.0;
    }

    .btn {
        color: white;
    }

    footer {
        margin-top: 5%;
        background: #142d49;
        padding: 5%;
        width: 100%;
        position: absolute;
    }

        footer p {
            text-align: left;
            font-size: 60%;
        }
</style>

<style scoped>
    .sezer {
        background: #e7334c;
        border: hidden;
        padding: 2%;
        font-size: calc(6px + 1.0vw);
        font-weight: bold;
        width: calc(30% + 1.0vw);
        margin: 1.5%;
    }
    .ProseMirror p {
        margin: 10em 0;
        text-align: center;
    }

    img {
        vertical-align: middle;
        border-style: none;
        width: 800px;
        max-width: 90%;
    }

    .save_class {
        margin-bottom: 1%;
        margin-top: 1%;
    }

    .blue {
        background: #2C2B64;
    }

    footer {
        margin-top: 5%;
        background: #2C2B64;
        padding: 5%;
        padding-left: 8%;
    }

        footer p {
            text-align: left;
            font-size: 50%;
        }


    .edit_buttons {
        margin-top: 1%;
    }

    .btn_save {
        background: rgb(111 216 103);
        border: hidden;
        padding: 1%;
        font-size: calc(60% + 2vw);
        /*border-radius: 15px;*/
        width: calc(30% + 1.5vw);
        margin: 1.5%;
        font-weight: 500;
        text-decoration-color: white;
        color: white;
    }

    .bub {
        color: rgb(18 33 82);
    }

    .material-icons {
        font-size: 10px;
    }
</style>


