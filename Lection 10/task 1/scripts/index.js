document.addEventListener('DOMContentLoaded', () => {
    const lists = document.querySelectorAll('.list');
    const boardCreateBtn = document.querySelector('.button');
    let draggedItem = null;

    function saveToLocalStorage() {
        const boards = document.querySelectorAll('.boards_item');
        const data = Array.from(boards).map(board => {
            const title = board.querySelector('.title').textContent;
            const items = Array.from(board.querySelectorAll('.list_item')).map(item => item.textContent.trim());
            return { title, items };
        });
        localStorage.setItem('boardsData', JSON.stringify(data));
    }

    function loadFromLocalStorage() {
        const data = JSON.parse(localStorage.getItem('boardsData'));
        if (data) {
            const boardsContainer = document.querySelector('.boards');
            boardsContainer.innerHTML = '';
            data.forEach(boardData => {
                const board = document.createElement('div');
                board.classList.add('boards_item');
                board.innerHTML = `<span contenteditable="true" class="title">${boardData.title}</span> <div class="list"></div>`;
                const list = board.querySelector('.list');
                boardData.items.forEach(itemText => {
                    const newItem = document.createElement('div');
                    newItem.classList.add('list_item');
                    newItem.draggable = true;
                    newItem.textContent = itemText;
                    list.append(newItem);
                });
                boardsContainer.append(board);
            });
            changeTitle();
            dragNdrop();
        }
    }

    function addTask() {
        const addBtn = document.querySelector('.buttons_add-item');
        const delBtn = document.querySelector('.buttons_del-item');
        const cardAddBtn = document.querySelector('.add_button');
        const textarea = document.querySelector('.textarea');
        const form = document.querySelector('.form');

        let value;

        cardAddBtn.addEventListener('click', () => {
            form.style.display = 'block';
            cardAddBtn.style.display = 'none';
            addBtn.style.display = 'none';

            textarea.addEventListener('input', () => {
                value = textarea.value;
                if (value) {
                    addBtn.style.display = 'block';
                } else {
                    addBtn.style.display = 'none';
                }
            });
        });

        delBtn.addEventListener('click', () => {
            textarea.value = '';
            value = '';
            form.style.display = 'none';
            cardAddBtn.style.display = 'flex';
        });

        addBtn.addEventListener('click', () => {
            if (!value) return;
            const newItem = document.createElement('div');
            newItem.classList.add('list_item');
            newItem.draggable = true;
            newItem.textContent = value;
            lists[0].append(newItem);

            textarea.value = '';
            value = '';
            form.style.display = 'none';
            cardAddBtn.style.display = 'flex';

            saveToLocalStorage();
            dragNdrop();
        });
    }

    function addBoard() {
        const boards = document.querySelector('.boards');
        const board = document.createElement('div');
        board.classList.add('boards_item');
        board.innerHTML = '<span contenteditable="true" class="title">Enter a name</span> <div class="list"></div>';

        boards.append(board);
        changeTitle();
        dragNdrop();

        saveToLocalStorage();

        const allBoardsCount = document.querySelectorAll('.boards_item').length;
        if (allBoardsCount >= 4) {
            boardCreateBtn.style.display = 'none';
        }
    }

    boardCreateBtn.addEventListener('click', addBoard);

    function changeTitle() {
        const titles = document.querySelectorAll('.title');

        titles.forEach(title => {
            title.addEventListener('click', e => e.target.textContent = '');
        });

        saveToLocalStorage();
        dragNdrop();
    }

    function dragNdrop() {
        const listsItem = document.querySelectorAll('.list_item');
        const lists = document.querySelectorAll('.list');

        listsItem.forEach(item => {
            item.addEventListener('dragstart', () => {
                draggedItem = item;
                setTimeout(() => {
                    item.style.display = 'none';
                }, 0);
            });
            item.addEventListener('dragend', () => {
                setTimeout(() => {
                    item.style.display = 'block';
                    draggedItem = null;
                }, 0);
            });

            item.addEventListener('dblclick', () => {
                item.remove(); // DELETE
                saveToLocalStorage();
            });

            lists.forEach(list => {
                list.addEventListener('dragover', e => e.preventDefault());

                list.addEventListener('dragenter', function (e) {
                    e.preventDefault();
                    this.style.backgroundColor = 'rgba(0,0,0,.3)';
                });

                list.addEventListener('dragleave', function (e) {
                    this.style.backgroundColor = 'rgba(0,0,0, 0)';
                });

                list.addEventListener('drop', function (e) {
                    this.style.backgroundColor = 'rgba(0,0,0, 0)';
                    this.append(draggedItem);
                    saveToLocalStorage();
                });
            });
        });
    }

    loadFromLocalStorage();
    addTask();
});
