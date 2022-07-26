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
                        <h2>Остались заполненные данные, уверены чтохотите прервать измнения?</h2>
                    </form>
                </div>
            </template>
            <template v-slot:footer>
                <div class="modal-footer">
                    <my-button class="create" @click="closeModal">Отмена</my-button>
                    <my-button class="create" @click="closeModalAll">Ок</my-button>
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
        },
        closeModalAll() {
            this.$emit('closeAllModal');
            this.show = false;
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
           top: 50%;
           left: 50%;
           width: 500px;
           height: 300px;
           margin-left: -250px;
           margin-top: -250px;
           background: rgba(0, 0, 0, 0);
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