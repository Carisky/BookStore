async function getQuote() {
    try {
        const response = await fetch("https://api.quotable.io/random");
        const quote = await response.json();
        return quote;
    } catch (error) {
        console.error("Error fetching quote:", error);
        throw error;
    }
}

async function displayQuote() {
    try {
        const quote = await getQuote();
        const quoteContainer = document.getElementById('quote_container');
        const quoteAuthorContainer = document.getElementById('quote_author_container');
        quoteContainer.innerHTML = `<div class="blockquote">${quote.content}</div>`;
        quoteAuthorContainer.innerHTML = `<div class="blockquote">${quote.author}</div>`;
    } catch (error) {
        
    }
}

window.onload = displayQuote;