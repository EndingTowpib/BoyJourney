from basetestcase import MyBaseTestCase
import time
import socket
class StartGameTestCase(MyBaseTestCase):
    def runTest(self):
        begin_btn=self.poco('Begin')
        begin_btn.click()
        time.sleep(3)
        self.assertTrue(self.poco('Character').wait(1),'StartGame Testing...')

if __name__=='__main__':
    import pocounit
    pocounit.main()