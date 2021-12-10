<template>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link type="text/css" rel="stylesheet" href="css/materialize.min.css" media="screen,projection" />


    <div class="home">
        <div class="img">
            <img src="../assets/star-shl.jpg" />
        </div>

        <video controls="controls" preload="metadata">
            <source src="../assets/WatGebeurtErMetBloed.mp4#t=3.5" type="video/mp4">
            Your browser does not support the video tag.
        </video>


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
            </div>
        </div>

        <div class="text_homepage">
            <editor-content 
                            :editor="editor"
                            v-model="content"
            />
            <pre>{{ content }}</pre>
        </div>



        <a class="homeButtons btn">Informatie over onderzoeken</a>
        <a class="homeButtons btn">Afspraak maken</a>
        <a class="homeButtons btn">Priklocaties</a>
        <br><br>
        <a class="homeButtons blue btn">Contact</a>
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

</template>


<script>
    import { Editor, EditorContent } from '@tiptap/vue-3'
    import StarterKit from '@tiptap/starter-kit'
    //const html = this.editor.getHTML()
    export default {
        components: {
            EditorContent,
        },

        data() {
            return {
                editor: null,
                content: null,
            }
        },

        mounted() {
            this.editor = new Editor({
                //content: '<p>I’m running Tiptap with Vue.js. 🎉</p>',
                content: "<p>Hello</p>",
                extensions: [
                    StarterKit,
                ],
            })
            //const json = editor.getJSON()
            //this.editor.commands.clearContent(true)

            //this.editor.commands.setContent('<p>Example Text</p>')


        },

        beforeUnmount() {
            this.editor.destroy()
        },
    }
</script>

<style>
    .btn:hover {
        opacity: 0.6;
    }

    .btn {
        color: white;
    }
</style>

<style scoped>
    .ProseMirror p {
        margin: 10em 0;
        text-align: center;
    }

    .img {
        vertical-align: middle;
        border-style: none;
    }

    img {
        vertical-align: middle;
        border-style: none;
        width: 800px;
        max-width: 90%;
    }

    img {
        vertical-align: middle;
        border-style: none;
        width: 800px;
        max-width: 80%;
    }

    .text_homepage {
        font-size: 60%;
        text-align: center;
        margin-top: 1%;
        margin-bottom: 3%;
        margin-left: 15%;
        margin-right: 15%;
    }

        .text_homepage p {
            cursor: pointer;
            padding: 4%;
            margin-right: 10%;
            margin-left: 10%;
            margin-bottom: 12%;
            border-radius: 15px;
            box-shadow: 0 0 10px 1px black;
            text-align: left;
        }

    video {
        margin-top: 10px;
        width: 640px;
        height: 360px;
    }


    @media screen and (max-width: 700px) {
        video {
            width: 320px;
            margin-top: 10px;
            height: 240px;
        }
    }

    .homeButtons {
        background: #E91E63;
        border: hidden;
        padding: 2%;
        font-size: 60%;
        border-radius: 15px;
        width: 60%;
        margin: 1.5%;
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

    .btn {
        opacity: 0.6;
    }

    .edit_buttons {
        margin-top: 3%;
    }

    .bub {
        color: rgb(18 33 82);
    }

    .material-icons {
        font-size: 10px;
    }
</style>

