<template>
    <section>
        <b-button :active="this.isAvailable">{{measurement}}</b-button>
    </section>
</template>

<script>
    export default {
        name: "ProductButton",
        props: ['measurement', 'quantity'],
        data(){
            return{
                isAvailable : false,
                outOfStockMsg : " (Out Of Stock)"
            }
        },
        beforeMount(){
            this.isAvailable = this.isAvailableCheck()
        },
        methods: {
            isAvailableCheck() {
                if(this.quantity > 0){
                    return true
                }
                else{
                    this.measurement += this.outOfStockMsg
                }
            }
        }
    }
</script>