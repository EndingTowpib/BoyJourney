from basetestcase import MyBaseTestCase

class FirstTestCase(MyBaseTestCase):
    def setUp(self) -> None:
        pass
    def runTest(self):
        self.assertTrue(self.poco('Character').wait(1),'char showing')
    def tearDown(self) -> None:
        pass

if __name__=='__main__':
    import pocounit
    pocounit.main()

