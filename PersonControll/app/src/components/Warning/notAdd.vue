<template>
    <div v-if="show" class="modal-shadow">
        <my-draggable>
            <template v-slot:header>
                <h1 class="invisible">
                    Тут необходим текст
                </h1>
            </template>
            <template v-slot:main>
                <div class="modal-content">
                    <form @submit.prevent>
                        <h2>Пользователь не добавлен</h2>
                    </form>
                </div>
            </template>
            <template v-slot:footer>
                <div class="modal-footer">
                    <my-button class="create" @click="closeModal">Ок</my-button>
                </div>
            </template>
        </my-draggable>
    </div>
</template>

<script>

export default {
    components: {
    },
    name: "ModalWindow",
    data: function () {
        return {
            show: false,
        }
    },
    methods: {
        closeModal: function () {
            this.show = false
        }
    }
}
</script>

<style scoped,
       lang="scss">
       form {
           display: flex;
           flex-direction: column;
       }
       
       .modal-shadow {
           position: absolute;
           top: 0;
           left: 0;
           min-height: 100%;
           width: 100%;
           background: rgba(0, 0, 0, 0.39);
       }
       
       h2 {
           margin-top: 15px;
           margin-bottom: 15px;
           align-self: center;
           padding: 10px 15px;
           color: teal;
           border: 1px solid teal;
       }
       </style>