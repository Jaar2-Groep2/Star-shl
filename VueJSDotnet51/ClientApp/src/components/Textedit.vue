<template>
    <div class="Textedit">
        <h3>
            Vue Trumbowyg demo
        </h3>
        <trumbowyg v-model="content" :config="config" class="editor" @tbw-blur="onBlur"></trumbowyg>
        <pre>
    {{content}}
    </pre>
    </div>

</template>


<script>
    var app = Vue.createApp({
        data() {
            return {
                content: '<h1>YEAH It works!!!</h1>',
                config: {
                    //http://alex-d.github.io/Trumbowyg/documentation.html#basic-options

                }
            }
        },
        components: {
            Trumbowyg: VueTrumbowyg.default
        },
        mounted() {
            console.log('app mounted')
        },
        methods: {
            onBlur(e) {
                console.log("blur", e)
            }
        }
    }).mount("#app");
</script>

<style scoped>
    body {
        font-family: Verdana, Arial, sans-sarif;
        background: #f8f8f8
    }

    pre {
        background: #ddd;
        padding: 10px
    }
</style>

