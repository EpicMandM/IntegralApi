// script.js

document.addEventListener('DOMContentLoaded', () => {
    const equationInput = document.getElementById('equation');
    const proceedButton = document.querySelector('button[type="submit"]');
    const resultDiv = document.getElementById('result');
    const urlDiv = document.getElementById('url');
    const resultSection = resultDiv.parentElement;

    let retryCount = 0;
    const maxRetries = 3;

    function fetchApi(apiUrl) {
        $.ajax({
            url: apiUrl,
            type: 'GET',
            success: function (result) {
                resultDiv.textContent = result.result;
                urlDiv.textContent = apiUrl;
                urlDiv.href = apiUrl;
                resultSection.removeAttribute('hidden');
                urlDiv.removeAttribute('hidden');
                retryCount = 0; // reset retry count after successful fetch
            },
            error: function (xhr, status, error) {
                if (retryCount < maxRetries) {
                    retryCount++;
                    setTimeout(() => fetchApi(apiUrl), 1000); // retry after 1 second
                } else {
                    console.error('Error fetching the API:', error);
                    resultDiv.textContent = 'Error occurred, please try again.';
                    resultDiv.removeAttribute('hidden');
                    urlDiv.setAttribute('hidden', true);
                }
            }
        });
    }

    proceedButton.addEventListener('click', () => {
        const equation = encodeURIComponent(equationInput.value);
        const apiUrl = `/api/equation/${equation}`;
        fetchApi(apiUrl);
    });
});
