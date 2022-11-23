# 檔案擺放與命名
1. 如果是 import 的，可沿用原本的資料夾及位置，但需要刪除用不到的部分
2. 其他像是 script/prefab/material 等，統一放在 Assets 下對應的資料夾，可依不同的 scene 再創建子資料夾，如 Assets/Scripts/Room1/EnemyController.cs
3. 各種命名盡量清楚明瞭，也可註解功用

# 操作流程
- General
1. git pull main
2. git checkout -b <your_new_branch>
3. development
4. git add .
5. git commit -m "<some msg>"
6. git push -u origin <your_new_branch>

- If there are conflicts
1. git rebase main
2. resolve conflicts
3. git add --all
4. git commit -m "<some msg>"
5. git push -u origin <your_new_branch> -f

- Review other people's branches
1. git checkout main
2. git fetch
3. git swicth <someone's branch>
