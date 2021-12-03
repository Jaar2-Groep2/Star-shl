<template>
    <editor-content :editor="editor" />
    <div>
    </div>
    
    <div>
        <div v-if="editor">
            <button @click="editor.chain().focus().toggleBold().run()" :class="{ 'is-active': editor.isActive('bold') }">
                bold
            </button>
        </div>
    </div>

</template>

<script>
    import { Editor, EditorContent } from '@tiptap/vue-3'
    import StarterKit from '@tiptap/starter-kit'

    export default {
        components: {
            EditorContent,
        },

        data() {
            return {
                editor: null,
            }
        },

        mounted() {
            this.editor = new Editor({
                content: '<p>Iedereen die bij ons komt, heeft vragen over gezondheid. Vragen die wij beantwoorden met betrouwbare medische diagnostiek.Achter elke diagnose schuilt een persoonlijk verhaal.Daarom geloven wij dat elke vraag onze speciale aandacht verdient voor een helder en betrouwbaar antwoord.< br ></p>',
                extensions: [
                    StarterKit,
                ],
            })
        },

        beforeUnmount() {
            this.editor.destroy()
        },
    }
</script>