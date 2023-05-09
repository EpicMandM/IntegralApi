// script.js

document.addEventListener('DOMContentLoaded', () => {
    const equationInput = document.getElementById('equation');
    const proceedButton = document.querySelector('button[type="submit"]');
    const resultDiv = document.getElementById('result');
    const urlDiv = document.getElementById('url');
    const resultSection = resultDiv.parentElement;


    proceedButton.addEventListener('click', async () => {
        const equation = encodeURIComponent(equationInput.value);
        //const apiUrl = `~/api/equation/${equation}`;
        const apiUrl = `https://newton.vercel.app/api/v2/integrate/${equation}`;
        

        try {
            const response = await fetch(apiUrl);
            if (!response.ok) {
                throw new Error(`HTTP error ${response.status}`);
            }
            const result = await response.json()

            resultDiv.textContent = result.result;
            urlDiv.textContent = apiUrl;
            urlDiv.href = apiUrl;
            resultSection.removeAttribute('hidden');
        } catch (error) {
            console.error('Error fetching the API:', error);
            resultDiv.textContent = 'Error occurred, please try again.';
            resultDiv.removeAttribute('hidden');
            urlDiv.setAttribute('hidden', true);
        }
    });
});
