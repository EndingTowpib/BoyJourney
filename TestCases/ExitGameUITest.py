from basetestcase import MyBaseTestCase
import time
import socket
class StartGameTestCase(MyBaseTestCase):
    def runTest(self):
        self.poco('Exit').click()
        time.sleep(3)
        self.assertRaises(socket.error,lambda: self.poco('Exit').click(),msg='ExitGame Testing...')

if __name__=='__main__':
    import pocounit
    pocounit.main()