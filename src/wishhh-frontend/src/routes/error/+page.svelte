<script lang="ts">
    import {page} from '$app/stores'
    import Logo from '$lib/components/Logo.svelte'

    const status = $page.url.searchParams.get('status')
</script>

<div class="center-placer">
    <div class="logo">
        <Logo size="100px"/>
    </div>
    <h2>Упс! Произошла ошибка!</h2>
    {#if status !== null}
        <span>Код: {status}</span>
    {/if}
    <a href="/">На главную</a>
</div>

<style lang="less">
  @import "../../lib/themes/default";

  .logo {
    color: @accentColor;
  }
  
  a:hover {
    text-decoration: underline;
    color: @accentColor;
  }
  
  .center-placer {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    gap: 30px;
    height: 100vh;
    width: 100%;
    background: @mainBackground;
    color: @foregroundColor;
    font: @monoFont;
  }
</style>