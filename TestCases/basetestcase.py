# coding=utf-8

from pocounit.case import PocoTestCase
from poco.drivers.unity3d.device import UnityEditorWindow
from pocounit.addons.poco.action_tracking import ActionTracker

from poco.drivers.unity3d import UnityPoco


class MyBaseTestCase(PocoTestCase):
    @classmethod
    def setUpClass(cls):
        super(MyBaseTestCase, cls).setUpClass()
        cls.poco = UnityPoco(('', 5001),device=UnityEditorWindow())

        # 启用动作捕捉(action tracker)
        action_tracker = ActionTracker(cls.poco)
        cls.register_addon(action_tracker)