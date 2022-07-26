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
                        <h2>Пользователь не найден</h2>
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
           top: 50%;
           left: 50%;
           width: 500px;
           height: 300px;
           margin-left: -250px;
           margin-top: -50px;
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
       
       .modal {
           background: #fff;
           border-radius: 8px;
           padding: 15px;
           min-width: 420px;
           max-width: 480px;
           position: absolute;
           top: 50%;
           left: 50%;
           transform: translate(-50%, -50%);
       
           &-close {
               border-radius: 50%;
               color: #fff;
               background: #2a4cc7;
               display: flex;
               align-items: center;
               justify-content: center;
               position: absolute;
               top: 7px;
               right: 7px;
               width: 30px;
               height: 30px;
               cursor: pointer;
           }
       
           &-title {
               color: #0971c7;
           }
       
           &-content {
               margin-bottom: 20px
           }
       
           &-footer {
               &__button {
                   background-color: #0971c7;
                   color: #fff;
                   border: none;
                   text-align: center;
                   padding: 8px;
                   font-size: 17px;
                   font-weight: 500;
                   border-radius: 8px;
                   min-width: 150px;
               }
           }
       }
       
       .invisible {
           visibility: hidden !important;
       }
       </style>