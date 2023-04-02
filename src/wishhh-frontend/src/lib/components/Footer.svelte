<script>
	import ghLogo from '../images/github-logo.svg';
	import tgLogo from '../images/tg-logo.svg';
	import emailLogo from '../images/email-logo.svg';
</script>

<div class='footer'>
	<hr>
	<span class='name'>WISHHH 2023 &copy;</span>
	<div class='contacts'>
		<span>Связь с нами</span>
		<ul>
			<li>
				<a href='/'>
					<img src={ghLogo} alt='gh' class='github'>
				</a>
			</li>
			<li>
				<a href='/'>
					<img src={emailLogo} alt='email'>
				</a>
			</li>
			<li>
				<a href='/'>
					<img src={tgLogo} alt='tg' class='telegram'>
				</a>
			</li>
		</ul>
	</div>
</div>

<style>
    .footer {
        display: flex;
        flex-direction: column;
        align-items: center;
        gap: 15px;
        margin-bottom: 50px;
        width: 100%;
        font-size: 10px;
    }

    .name {
        font-size: 12px;
    }

    .contacts {
        display: flex;
        flex-direction: column;
        align-items: center;
        gap: 10px;
    }

    ul {
        list-style: none;
        display: grid;
        grid-template-columns: repeat(3, 1fr);
        grid-gap: 40px;
    }

    li a {
        min-width: 40px;
        max-width: 40px;

        min-height: 40px;
        max-height: 40px;
        overflow: hidden;
    }

    li a > img {
        max-width: 100%;
        max-height: 100%;
    }

		li a:hover {
				transform: scale(1.1);
		}
		
    .github {
        transform: scale(0.8, 0.8);
    }

    .telegram {
        transform: scale(1.2, 1.2);
    }

    hr {
        height: 4px;
        background: black;
        color: black;
        width: 90%;
    }
</style>