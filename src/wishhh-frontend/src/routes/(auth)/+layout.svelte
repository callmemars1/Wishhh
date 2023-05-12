<script lang="ts">
    import {onMount} from "svelte";
    import {getAuth, onAuthStateChanged} from "firebase/auth"
    import app from "$lib/scripts/firebase";
    import {redirect} from "@sveltejs/kit";

    onMount(() => {
        const auth = getAuth();
        onAuthStateChanged(auth, (user) => {
            if (user) {
                console.log("logged in!")
            }
            else {
                console.log('cringe')
            }
        })
    })
</script>

<div class="center-placer">
    <slot/>
</div>

<style lang="less">
  @import "../../lib/themes/default";

  .center-placer {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    font: @font;
    font-size: @size-xs;
    height: 100vh;
    width: 100%;
    background: @mainBackground;
    color: @foregroundColor
  }
</style>