# 機能
AnimationParametersの一覧と現在の値を表示します。

# インストール方法
AnimationParametersViewer.unitypackageをインポートして下さい

# アンインストール方法
Assets/AnimationParametersViewer フォルダを削除して下さい

# 何に使うもの？
主としてFXレイヤの開発を行う時のAnimationParametersをリアルタイムに確認する目的で作成しました。
ExpressionParametersでなくても表示されます。

#使用法(FXを想定)
- Av3 EmulatorをVCCからプロジェクトに追加
- UnityのToolsメニュー→Avatars 3.0 Emulator→Enableをクリック
- UnityのToolsメニュー→Avatars 3.0 Emulator→Settings→「Default Animator To Debug」を「FX」に設定
- AnimationParametersViewer.unitypackageをインポート
- UnityのAPVメニュー→Viewをクリック
- UnityのPlayボタンをクリック

# 注意
毎F処理をしているので環境によって重くなる可能性があります。

# Source Code
https://github.com/pandravrc/DBTPractice

# 依存関係
Lyuma's Avatars 3.0 Emulatorに依存します。
https://booth.pm/ja/items/3480610　（VCC経由の導入が推奨です。）

# 開発・動作環境
次の環境で開発し、動作を確認しています。
- VRChat SDK 3.3.0
- Av3 Emulator 3.3.1

# ライセンス
MIT ライセンスに基づきます。