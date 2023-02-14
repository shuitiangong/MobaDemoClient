using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{

    public class BaseWindow
    {

        protected Transform transform;//窗体
        protected string resName;//资源名称
        protected bool resident; //是否常驻
        protected bool visible = false;//是否可见
        protected WindowType selfType;//窗体类型
        protected ScenesType scenesType;//场景类型

        //UI控件 按钮
        protected Button[] buttonList;//按钮列表

        //需要给子类提供的接口:
        //初始化
        protected virtual void Awake()
        {
            //表示隐藏的物体也会查找
            buttonList = transform.GetComponentsInChildren<Button>(true);
            RegisterUIEvent();
        }

        //UI事件的注册
        protected virtual void RegisterUIEvent()
        {

        }

        //添加监听游戏事件
        protected virtual void OnAddListener()
        {

        }

        //移除游戏事件
        protected virtual void OnRemoveListener()
        {

        }

        //每次打开
        protected virtual void OnEnable()
        {

        }

        //每次关闭
        protected virtual void OnDisable()
        {

        }

        //每帧更新
        public virtual void Update(float deltaTime)
        {

        }


        //---------------WindowManager

        public void Open()
        {
            if (transform == null)
            {
                if (Create())
                {
                    Awake();//初始化
                }
            }

            if (transform.gameObject.activeSelf == false)
            {
                UIRoot.SetParent(transform, true, selfType == WindowType.TipsWindow);
                transform.gameObject.SetActive(true);
                visible = true;
                OnEnable();//调用激活时候触发的事件
                OnAddListener();//添加事件
            }
        }

        public void Close(bool isDestroy = false)
        {
            if (transform.gameObject.activeSelf == true)
            {
                OnRemoveListener();//移除游戏事件
                OnDisable();//隐藏时候触发的事件
                if (isDestroy == false)
                {
                    if (resident)
                    {
                        transform.gameObject.SetActive(false);
                        UIRoot.SetParent(transform, false, false);

                    }
                    else
                    {
                        GameObject.Destroy(transform.gameObject);
                        transform = null;
                    }
                }
                else
                {
                    GameObject.Destroy(transform.gameObject);
                    transform = null;
                }


            }
            //不可见的状态
            visible = false;
        }

        public void PreLoad()
        {
            if (transform == null)
            {
                if (Create())
                {
                    Awake();
                }
            }
        }

        //获取场景类型
        public ScenesType GetScenesType()
        {
            return scenesType;
        }

        //窗体类型
        public WindowType GetWindowType()
        {
            return selfType;
        }

        //获取根节点
        public Transform GetRoot()
        {
            return transform;
        }

        //是否可见
        public bool IsVisible()
        {
            return visible;
        }

        //是否常驻
        public bool IsREsident()
        {
            return resident;
        }


        //------内部----
        private bool Create()
        {
            if (string.IsNullOrEmpty(resName))
            {
                return false;
            }

            if (transform == null)
            {
                var obj = Resources.Load<GameObject>(resName);
                if (obj == null)
                {
                    Debug.LogError($"未找到UI预制件{selfType}， {resName}");
                    return false;
                }
                transform = GameObject.Instantiate(obj).transform;

                transform.gameObject.SetActive(false);

                UIRoot.SetParent(transform, false, selfType == WindowType.TipsWindow);
                return true;
            }

            return true;
        }


    }
}