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
                        <h2>Вы действительно хотите удалить пользователя?</h2>
                    </form>
                </div>
            </template>
            <template v-slot:footer>
                <div class="modal-footer">
                    <my-button class="create" @click="deleteDate">Подтвердить</my-button>
                    <my-button class="create" @click="closeModal">Отменить</my-button>
                </div>
            </template>
        </my-draggable>
        <Error ref="Error"></Error>
        <CopyDelete ref="CopyDelete"></CopyDelete>
        <AlreadyUserDelete ref="alreadyUserDelete"></AlreadyUserDelete>
    </div>
</template>

<script>
import axios from 'axios';
import Error from './Error.vue';
import CopyDelete from './copyDelete.vue';
import AlreadyUserDelete from './alreadyUserDelete.vue';


export default {
        components: {
    Error,
    CopyDelete,
    AlreadyUserDelete
},
    name: "ModalWindow",
    data: function () {
        return {
            show: false,
        }
    },
    methods: {
        closeModal: function () {
            this.$emit('active');
            this.show = false
        },
        async deleteDate(){
            try{
                const responce = await axios.get('https://localhost:44310/EditTableColumn/DeleteColumn?id=' + this.id +  '');
                console.log(responce);
                if(responce.data.message == "Операция выполнена"){
                    alert('Пользователь удалён')
                    this.$refs.alreadyUserDelete.show = true;
                }
                else{
                    alert('Пользователь уже удалён')
                    this.$refs.CopyDelete.show = true;
                }
                this.closeModal();
            }catch(e){
                this.$refs.Error.show = true;
            }
        },
    },
    props: {
        id: String
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
    
    .invisible {
           visibility: hidden !important;
       }
    </style>