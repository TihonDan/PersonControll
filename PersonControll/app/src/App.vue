<template>
    <div class="container">
        <my-button class="show-modal-form" @click="showModalForm" :disabled="!isActive">Open application</my-button>
        <post-form-vue ref="modalform"></post-form-vue>
    </div>
</template>

<script>

import PostFormVue from './components/PostForm.vue';

export default {
    components: {
        PostFormVue,
    },
    data() {
        return {
            isActive: true
        }
    },
    methods: {
        showModalForm: function () {
            this.$refs.modalform.show = true;
        }
    }
}
</script>

<style>
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

.container {
    padding: 20px;
}
</style>

